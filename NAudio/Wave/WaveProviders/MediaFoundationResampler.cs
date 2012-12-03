﻿using System;
using System.Runtime.InteropServices;
using NAudio.Dmo;
using NAudio.MediaFoundation;

namespace NAudio.Wave
{
    /// <summary>
    /// The Media Foundation Resampler Transform
    /// </summary>
    public class MediaFoundationResampler : MediaFoundationTransform
    {
        private int resamplerQuality;

        /// <summary>
        /// Creates the Media Foundation Resampler, allowing modifying of sample rate, bit depth and channel count
        /// </summary>
        /// <param name="sourceProvider">Source provider, must be PCM</param>
        /// <param name="outputFormat">Output format, must also be PCM</param>
        public MediaFoundationResampler(IWaveProvider sourceProvider, WaveFormat outputFormat)
            : base(sourceProvider, outputFormat)
        {
            if (sourceProvider.WaveFormat.Encoding != WaveFormatEncoding.Pcm && sourceProvider.WaveFormat.Encoding != WaveFormatEncoding.IeeeFloat)
                throw new ArgumentException("Input must be PCM or IEEE float", "sourceProvider");
            if (outputFormat.Encoding != WaveFormatEncoding.Pcm && outputFormat.Encoding != WaveFormatEncoding.IeeeFloat)
                throw new ArgumentException("Output must be PCM or IEEE float", "outputFormat");
            MediaFoundationApi.Startup();
            ResamplerQuality = 60; // maximum quality

            // n.b. we will create the resampler COM object on demand in the Read method, 
            // to avoid threading issues but just
            // so we can check it exists on the system we'll make one so it will throw an 
            // exception if not exists
            var comObject = new ResamplerMediaComObject();
            Marshal.ReleaseComObject(comObject);
        }

        /// <summary>
        /// Creates a resampler with a specified target output sample rate
        /// </summary>
        /// <param name="sourceProvider">Source provider</param>
        /// <param name="outputSampleRate">Output sample rate</param>
        public MediaFoundationResampler(IWaveProvider sourceProvider, int outputSampleRate)
            : this(sourceProvider, CreateOutputFormat(sourceProvider.WaveFormat, outputSampleRate))
        {

        }

        /// <summary>
        /// Creates and configures the actual Resampler transform
        /// </summary>
        /// <returns>A newly created and configured resampler MFT</returns>
        protected override IMFTransform CreateTransform()
        {
            var comObject = new ResamplerMediaComObject();
            var resamplerTransform = (IMFTransform)comObject;

            var inputMediaFormat = MediaFoundationApi.CreateMediaTypeFromWaveFormat(sourceProvider.WaveFormat);
            resamplerTransform.SetInputType(0, inputMediaFormat, 0);
            Marshal.ReleaseComObject(inputMediaFormat);

            var outputMediaFormat = MediaFoundationApi.CreateMediaTypeFromWaveFormat(outputWaveFormat);
            resamplerTransform.SetOutputType(0, outputMediaFormat, 0);
            Marshal.ReleaseComObject(outputMediaFormat);

            //MFT_OUTPUT_STREAM_INFO pStreamInfo;
            //resamplerTransform.GetOutputStreamInfo(0, out pStreamInfo);
            // if pStreamInfo.dwFlags is 0, then it means we have to provide samples

            // setup quality
            var resamplerProps = (IWMResamplerProps)comObject;
            // 60 is the best quality, 1 is linear interpolation
            resamplerProps.SetHalfFilterLength(ResamplerQuality);
            // may also be able to set this using MFPKEY_WMRESAMP_CHANNELMTX on the
            // IPropertyStore interface.
            // looks like we can also adjust the LPF with MFPKEY_WMRESAMP_LOWPASS_BANDWIDTH
            return resamplerTransform;
        }

        /// <summary>
        /// Gets or sets the Resampler quality. n.b. set the quality before starting to resample.
        /// 1 is lowest quality (linear interpolation) and 60 is best quality
        /// </summary>
        public int ResamplerQuality
        {
            get { return resamplerQuality; }
            set 
            { 
                if (value < 1 || value > 60)
                    throw new ArgumentOutOfRangeException("Resampler Quality must be between 1 and 60");
                resamplerQuality = value; 
            }
        }

        private static WaveFormat CreateOutputFormat(WaveFormat inputFormat, int outputSampleRate)
        {
            WaveFormat outputFormat;
            if (inputFormat.Encoding == WaveFormatEncoding.Pcm)
            {
                outputFormat = new WaveFormat(outputSampleRate,
                    inputFormat.BitsPerSample,
                    inputFormat.Channels);
            }
            else if (inputFormat.Encoding == WaveFormatEncoding.IeeeFloat)
            {
                outputFormat = WaveFormat.CreateIeeeFloatWaveFormat(outputSampleRate,
                    inputFormat.Channels);
            }
            else
            {
                throw new ArgumentException("Can only resample PCM or IEEE float");
            }
            return outputFormat;
        }
    }
}