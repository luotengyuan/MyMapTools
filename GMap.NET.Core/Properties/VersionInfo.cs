﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyCulture("")]
[assembly: AssemblyCompany("FLAT EARTH")]
[assembly: AssemblyCopyright("Copyright © FLAT EARTH")]
[assembly: AssemblyTrademark("email@radioman.lt")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.7.5")]   
[assembly: AssemblyInformationalVersion("1.7.5")]

#if !PocketPC
[assembly: AssemblyFileVersion("1.7.5")]
#endif
