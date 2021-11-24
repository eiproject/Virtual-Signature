#include <opencv2/core.hpp>
#include <opencv2/videoio.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>
#include <opencv2/objdetect.hpp>
#include <opencv2/video/tracking.hpp>
#include "opencv2\objdetect\objdetect.hpp"
#include <vector>
#include <stdio.h>
#include <Windows.h>
#include <iostream>

#include "videocapture.h"

using namespace cv;
using namespace std;

string SayHi(){
    return "hi";
}

int CallNumber(){
    return 99;
}

void OpticalFlowDetection(Mat before, Mat after, Mat &flow_result, Mat &after_processed){
    if (after.empty()) return;
    after.copyTo(after_processed);
    cv::calcOpticalFlowFarneback(
        before, // prev
        after, // next
        flow_result, // result
        .5, // pyr_scale
        1, // levels
        10, // winsize
        2, // iterations
        10, // poly_n
        5.0, // poly_sigma
        0 // flags
    );
    for (int y = 0; y < after.rows; y += 5) {
        for (int x = 0; x < after.cols; x += 5)
        {
            // get the flow from y, x position * 3 for better visibility
            const Point2f flowatxy = flow_result.at<Point2f>(y, x) * 1;
            // draw line at flow direction
            line(after_processed, Point(x, y), Point(cvRound(x + flowatxy.x), cvRound(y + flowatxy.y)), Scalar(255));
            // draw initial point
            circle(after_processed, Point(x, y), 1, Scalar(50), -1);
        }
    }
}

int main(int argc, char* argv[])
{
    cv::Mat img1, img2, flow, processed_img;
    cv::VideoWriter writer;

    cv::VideoCapture cap;
    cap.open(0);

    cv::namedWindow("cat", cv::WINDOW_AUTOSIZE);

    cap >> img1;
    cvtColor(img1, img1, cv::COLOR_BGR2GRAY);
    double fps = cap.get(cv::CAP_PROP_FPS);
    cv::Size tamano((int)cap.get(cv::CAP_PROP_FRAME_WIDTH), (int)cap.get(cv::CAP_PROP_FRAME_HEIGHT));

    for (;;) {        
        cap >> img2;
        cvtColor(img2, img2, COLOR_BGR2GRAY);

        // img1 and img2 is a grayscale image
        OpticalFlowDetection(img1, img2, flow, processed_img);

        img2.copyTo(img1);
        imshow("cat", processed_img);
        if (waitKey(5) >= 0) break;
    }
    cap.release();
    return 0;
}
