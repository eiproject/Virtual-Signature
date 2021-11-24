#include <opencv2/core.hpp>
#include <iostream>

using namespace cv;

#pragma once
#define OPTICALFLOW_API __declspec(dllexport)

// Get the position of the current value in the sequence.
extern "C" OPTICALFLOW_API void OpticalFlowDetection(Mat before, Mat after, Mat &flow_result, Mat &after_processed);
extern "C" OPTICALFLOW_API std::string SayHi();
extern "C" OPTICALFLOW_API int CallNumber();

// gcc -shared -o videocapture.dll videocapture.cpp

// C:\CPP\v-9.4.0\mingw64\bin\g++.exe -fdiagnostics-color=always -g C:\Lab-Formulatrix\VirtualSign\VirtualSign.Processor\videocapture.cpp -o C:\Lab-Formulatrix\VirtualSign\VirtualSign.Processor\videocapture.exe -I C:\opencv\OpenCV-MinGW-Build-OpenCV-4.5.2-x64\include -L C:\opencv\OpenCV-MinGW-Build-OpenCV-4.5.2-x64\x64\mingw\bin -l libopencv_calib3d452 -l libopencv_core452 -l libopencv_dnn452 -l libopencv_features2d452 -l libopencv_flann452 -l libopencv_gapi452 -l libopencv_highgui452 -l libopencv_imgcodecs452 -l libopencv_imgproc452 -l libopencv_ml452 -l libopencv_objdetect452 -l libopencv_photo452 -l libopencv_stitching452 -l libopencv_video452 -l libopencv_videoio452 -l opencv_videoio_ffmpeg452_64

// C:\CPP\v-9.4.0\mingw64\bin\gcc.exe -fdiagnostics-color=always -shared -g C:\Lab-Formulatrix\VirtualSign\VirtualSign.Processor\videocapture.cpp -o C:\Lab-Formulatrix\VirtualSign\VirtualSign.Processor\videocapture.dll -I C:\opencv\OpenCV-MinGW-Build-OpenCV-4.5.2-x64\include -L C:\opencv\OpenCV-MinGW-Build-OpenCV-4.5.2-x64\x64\mingw\bin -l libopencv_calib3d452 -l libopencv_core452 -l libopencv_dnn452 -l libopencv_features2d452 -l libopencv_flann452 -l libopencv_gapi452 -l libopencv_highgui452 -l libopencv_imgcodecs452 -l libopencv_imgproc452 -l libopencv_ml452 -l libopencv_objdetect452 -l libopencv_photo452 -l libopencv_stitching452 -l libopencv_video452 -l libopencv_videoio452 -l opencv_videoio_ffmpeg452_64
