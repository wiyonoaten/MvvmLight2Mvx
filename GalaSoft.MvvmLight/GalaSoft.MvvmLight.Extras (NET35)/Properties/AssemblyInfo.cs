// *************************************30*************************************
// <copyright file="AssemblyInfo.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2013
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>3.11.2009</date>
// <project>GalaSoft.MvvmLight.Extras</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this project or http://www.galasoft.ch/license_MIT.txt
// </license>
// <LastBaseLevel>BL0023</LastBaseLevel>
// ****************************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

#if !NETFX_CORE && !PORTABLE
#if !XAMARIN
using System.Windows.Markup;
#endif
#endif

[assembly: AssemblyTitle("GalaSoft.MvvmLight.Extras")]
[assembly: AssemblyDescription("Extras components to implement Model-View-ViewModel applications in WPF, Silverlight and Windows Phone 7")]

#if !NETFX_CORE && !PORTABLE
#if !XAMARIN
[assembly: XmlnsDefinition("http://www.galasoft.ch/mvvmlight", "GalaSoft.MvvmLight.Command")]
#endif
#endif
#if !PORTABLE
[assembly:NeutralResourcesLanguage("en-US")]
#endif