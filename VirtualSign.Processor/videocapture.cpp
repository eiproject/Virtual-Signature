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

using namespace cv;
using namespace std;


int main(int argc, char* argv[])
{
    cv::Mat res, img1, img2, img2Original, img2OriginalC;
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
        if (img2.empty()) break;

        img2.copyTo(img2OriginalC);
        cvtColor(img2, img2, COLOR_BGR2GRAY);
        img2.copyTo(img2Original);
        cv::calcOpticalFlowFarneback(
            img1, // prev
            img2, // next
            res, // result
            .5, // pyr_scale
            1, // levels
            10, // winsize
            2, // iterations
            10, // poly_n
            5.0, // poly_sigma
            0 // flags
        );
        for (int y = 0; y < img2.rows; y += 5) {
            for (int x = 0; x < img2.cols; x += 5)
            {
                // get the flow from y, x position * 3 for better visibility
                const Point2f flowatxy = res.at<Point2f>(y, x) * 1;
                // draw line at flow direction
                line(img2OriginalC, Point(x, y), Point(cvRound(x + flowatxy.x), cvRound(y + flowatxy.y)), Scalar(255, 0, 0));
                // draw initial point
                circle(img2OriginalC, Point(x, y), 1, Scalar(0, 0, 0), -1);
            }
        }
        img2Original.copyTo(img1);
        imshow("cat", img2OriginalC);
        //writer << img2OriginalC;    
        if (waitKey(5) >= 0) break;
    }
    cap.release();
    return 0;
}
