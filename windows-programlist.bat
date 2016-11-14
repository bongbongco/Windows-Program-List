echo ##TAG_REG32 > %computerName%.txt
reg query "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall" /s >> %computerName%.txt
echo ##TAG_REG3264  >> %computerName%.txt
reg query "HKLM\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall" /s  >> %computerName%.txt
echo ##TAG_DIR_D >> %computerName%.txt
dir d: /b /on /s >> %computerName%.txt
echo ##TAG_DIR_Program Files >> %computerName%.txt
dir "C:\Program Files" /b /on /s >> %computerName%.txt
echo ##TAG_DIR_Program Files(x86) >> %computerName%.txt
dir "C:\Program Files (x86)" /b /on /s >> %computerName%.txt
echo ##TAG_END >> %computerName%.txt

