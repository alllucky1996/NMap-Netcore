# NMap-Netcore
source by https://archive.codeplex.com/?p=dotnmap
CodePlex ArchiveOpen Source Project Archive

# DotNMap -> NMap-Netcore

A type library that can be used to work with NMap scan results in .net.

A simple C# library containing the types necessary to deserialize Nmap xml output files.

Nmap is NOT included as part of this solution. You will need to install it on your own. The download and ample instructions are available @ http://nmap.org/

Also included is a simple demo application that will launch Nmap with some general options and scan www.scanme.org. This is a test proxy that is hosted by the maker of Nmap.

Executing the demo requires one argument indicating the target and an optional argument for the output directory.

The host is scanned using Nmap it outputs the results to an xml file.



The demo then deserializes the xml file into an nmaprun object and dumps it’s contents to the console.



© 2006-2018 MicrosoftShutdown AnnouncementSupport

© 2018-2020 Support by nguyen anh dung
