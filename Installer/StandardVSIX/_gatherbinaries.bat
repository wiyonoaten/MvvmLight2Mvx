rem @echo off

if not exist ..\InstallItems\VSIX md ..\InstallItems\VSIX
if not exist ..\InstallItems\VSIX\Release md ..\InstallItems\VSIX\Release

if exist ".\MvvmLight.VS10\bin\Release\MvvmLight.VS2010.vsix" copy ".\MvvmLight.VS10\bin\Release\MvvmLight.VS2010.vsix" ..\InstallItems\VSIX\Release\MvvmLight.VS2010.vsix
if exist ".\MvvmLight.VS11\bin\Release\MvvmLight.VS2012.vsix" copy ".\MvvmLight.VS11\bin\Release\MvvmLight.VS2012.vsix" ..\InstallItems\VSIX\Release\MvvmLight.VS2012.vsix

if exist ".\MvvmLight.VCSx10\bin\Release\MvvmLight.WPFExpress2010.vsix" copy ".\MvvmLight.VCSx10\bin\Release\MvvmLight.WPFExpress2010.vsix" ..\InstallItems\VSIX\Release\MvvmLight.WPFExpress2010.vsix
if exist ".\MvvmLight.VCSx11\bin\Release\MvvmLight.WPFExpress2012.vsix" copy ".\MvvmLight.VCSx11\bin\Release\MvvmLight.WPFExpress2012.vsix" ..\InstallItems\VSIX\Release\MvvmLight.WPFExpress2012.vsix

if exist ".\MvvmLight.VSWin8x11\bin\Release\MvvmLight.Win8Express2012.vsix" copy ".\MvvmLight.VSWin8x11\bin\Release\MvvmLight.Win8Express2012.vsix" ..\InstallItems\VSIX\Release\MvvmLight.Win8Express2012.vsix
if exist ".\MvvmLight.VSWP8x11\bin\Release\MvvmLight.WP8Express2012.vsix" copy ".\MvvmLight.VSWP8x11\bin\Release\MvvmLight.WP8Express2012.vsix" ..\InstallItems\VSIX\Release\MvvmLight.WP8Express2012.vsix

if exist ".\MvvmLight.VWDx10\bin\Release\MvvmLight.SilverlightExpress2010.vsix" copy ".\MvvmLight.VWDx10\bin\Release\MvvmLight.SilverlightExpress2010.vsix" ..\InstallItems\VSIX\Release\MvvmLight.SilverlightExpress2010.vsix
if exist ".\MvvmLight.VWDx11\bin\Release\MvvmLight.SilverlightExpress2012.vsix" copy ".\MvvmLight.VWDx11\bin\Release\MvvmLight.SilverlightExpress2012.vsix" ..\InstallItems\VSIX\Release\MvvmLight.SilverlightExpress2012.vsix

