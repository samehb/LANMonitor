# LANMonitor

![LANMonitor](http://i.imgur.com/T1pXZg8.png)

## Introduction
LANMonitor is a project that allows you to detect the devices (computers, phones, tablets, etc.) connected to your local network. It provides detailed information which can be used to indentify them such as names (if possible), MAC addresses, and vendors. It can also be used as a network diagnostic tool to monitor the connectivity of devices.

## Features
1. Detects and displays hostname (if possible), MAC address, first seen, last seen, interface vendor (related to the MAC address), adnd status.
2. Allows you to add a description to the device to be used with notifications instead of the hostname.
3. Notifies you when devices join or leave your network (tray icon).
4. Allows you to exclude specific devices from notifications.
5. Allows you to export the list of the devices detected for further processing.
6. Facilitates copying details from the list of detected devices.
7. Enables you to reset the list of devices. Also, allows you to reset the ARP cache if you have any problems with devices entries.

## Installation

1. Start by downloading the file from [here](https://github.com/samehb/LANMonitor/blob/master/Binaries/LANMonitor.zip?raw=true).
2. Extract the .zip file from step 1 into any folder of choice.
3. That is it. Start the program by executing LANMonitor.exe. Skip the last step if you are not a developer.
4. If you are a developer and want to modify this project, make sure that the LANMonitor.db database file is inlcuded with LANMonitor.exe. I already added it at the debug path, so you can compile the project and start right away. I also added the database inside the Database folder to make it easier for you.

## Usage

1. When you start the program it will begin scanning your network. It will take a while for the first run.
2. Within two minutes (depends on the number of connected devices) you will begin seeing the entries on your interface (GUI).
3. If you see anything on the list of devices that you want to copy, simply right click the cell detail and it will get copied into the clipboard.
4. If you want to disable notifications for a device (like your phone), go to its entry and find the checkbox at the last column then uncheck it. You will no longer receive any notifications related to that unchecked device.
5. If you find some devices with "Unknown" values that means your nework has a limitation (read below). You can go ahead and modify the Description value and the program will notify you with those Descriptions instead of "Unknown" values.
5. You can minizie the program into the tray. You will still see the notifications but without seeing the interface. Left click the tray icon (LM gray icon) to maximize and return to the interface. Note that you can scroll over the LM tray icon to see who is connected to the network without having to go into the interface.
6. You can export the entries on your interface by going through File -> Save List and saving the text file at any location.
7. If for any reason you want to reset the list of entries and start fresh, nvaigate to Tools -> Clear Devices.
8. When your ARP cache receives erroneous values, you will have to reset it by navigating to Tools -> Clear Interface.
9. If you want to select a different network interface to monitor, navigate to Tools -> Settings. Inside it you will be able to select the network interface, scan refresh interval, and the number of devices to scan from the base ip (I will add a start address feature in the future). Do not change those values unless you know what you are doing.

## Limitations
There is a limitation when it comes to LANMonitor. It is actually hardware related. In some network setups you will not be able to detect hostnames. I will not discuss this issue here. Though, If you must, you can create your own DNS server to overcome this limitation. If you do not have much IT experience, you can go ahead and use the Interface Vendor column to identify the device, then add a name to its Description. After that, the program will use the description value instead of the name as mentioned.

## Copyright
License: CC BY-NC-SA 4.0 (Attribution-NonCommercial-ShareAlike 4.0 International)

Read file [LICENSE](LICENSE)

## Links

[Blog](http://sres.tumblr.com)

[Project Information](http://sres.tumblr.com/post/146297641963/lanmonitor-detect-users-on-your-local-network)
