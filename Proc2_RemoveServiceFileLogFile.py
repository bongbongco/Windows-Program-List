#!/usr/bin/env python
import re
from multiprocessing import Process


destinationFileName = "PATH&NAME"
limit = 1000000

def ExtractEffectiveData(workDirectory, lineNumber):
    fileIndex = 1
    sourceReader = open(workDirectory + destinationFileName + ".txt", 'r')
    destinationWriter = open(workDirectory + destinationFileName + "_" + str(fileIndex)+".txt", 'a')

    while True:
        line = sourceReader.readline()
        if line == '':
            break
        if (line[-11:] == ".resources\n"
            or line[-8:] == ".config\n"
            or line[-8:] == ".Config\n"
            or line[-8:] == ".cshtml\n"
            or line[-8:] == ".vbhtml\n"
            or line[-7:] == ".class\n"
            or line[-6:] == ".html\n"
            or line[-6:] == ".conf\n"
            or line[-6:] == ".json\n"
            or line[-6:] == ".aspx\n"
            or line[-6:] == ".asmx\n"
            or line[-6:] == ".asax\n"
            or line[-6:] == ".docx\n"
            or line[-6:] == ".resx\n"
            or line[-6:] == ".ascx\n"
            or line[-6:] == ".xlsx\n"
            or line[-6:] == ".vbs_\n"
            or line[-5:] == ".png\n"
            or line[-5:] == ".sig\n"
            or line[-5:] == ".rtf\n"
            or line[-5:] == ".ocx\n"
            or line[-5:] == ".MIB\n"
            or line[-5:] == ".spm\n"
            or line[-5:] == ".qid\n"
            or line[-5:] == ".grd\n"
            or line[-5:] == ".cab\n"
            or line[-5:] == ".bin\n"
            or line[-5:] == ".sis\n"
            or line[-5:] == ".fxf\n"
            or line[-5:] == ".tag\n"
            or line[-5:] == ".sys\n"
            or line[-5:] == ".cat\n"
            or line[-5:] == ".inf\n"
            or line[-5:] == ".inc\n"
            or line[-5:] == ".rll\n"
            or line[-5:] == ".mui\n"
            or line[-5:] == ".plg\n"
            or line[-5:] == ".rpm\n"
            or line[-5:] == ".doc\n"
            or line[-5:] == ".vbs\n"
            or line[-5:] == ".swf\n"
            or line[-5:] == ".msi\n"
            or line[-5:] == ".xsd\n"
            or line[-5:] == ".cfg\n"
            or line[-5:] == ".nlp\n"
            or line[-5:] == ".reg\n"
            or line[-5:] == ".ini\n"
            or line[-5:] == ".rsp\n"
            or line[-5:] == ".tlb\n"
            or line[-5:] == ".sql\n"
            or line[-5:] == ".jpg\n"
            or line[-5:] == ".htm\n"
            or line[-5:] == ".gif\n"
            or line[-5:] == ".xml\n"
            or line[-5:] == ".css\n"
            or line[-5:] == ".txt\n"
            or line[-5:] == ".ico\n"
            or line[-5:] == ".jsp\n"
            or line[-5:] == ".jar\n"
            or line[-5:] == ".bat\n"
            or line[-5:] == ".cpp\n"
            or line[-5:] == ".ttf\n"
            or line[-5:] == ".pyc\n"
            or line[-5:] == ".pyo\n"
            or line[-5:] == ".crt\n"
            or line[-5:] == ".yml\n"
            or line[-5:] == ".xsl\n"
            or line[-5:] == ".log\n"
            or line[-5:] == ".bak\n"
            or line[-5:] == ".cmd\n"
            or line[-5:] == ".dll\n"
            or line[-5:] == ".asp\n"
            or line[-5:] == ".pdb\n"
            or line[-5:] == ".zip\n"
            or line[-5:] == ".ilg\n"
            or line[-5:] == ".mib\n"
            or line[-5:] == ".cxm\n"
            or line[-5:] == ".idx\n"
            or line[-5:] == ".dat\n"
            or line[-5:] == ".JPG\n"
            or line[-4:] == ".js\n"
            or line[-4:] == ".vb\n"
            or line[-4:] == ".db\n"
            or line[-4:] == ".sh\n"
            or line[-4:] == ".py\n"
            or line[-4:] == ".gz\n"
            or line[-4:] == ".mo\n"
            or line[-4:] == ".so\n"
            or line[-4:] == ".pl\n"
            or line[-4:] == ".md\n"
            or line[-4:] == ".cs\n"
            or line[-3:] == ".h\n"
            or line[-3:] == ".c\n"
            or line[-3:] == ".o\n"
            or re.match('.*/log/.*', line)
            or re.match('.*\.log_.*', line)
            or re.match('.*/logs/.*', line)
            or re.match('.*/bak/.*', line)
            or re.match('.*/bakup/.*', line)
            or re.match('.*/back/.*', line)
            or re.match('.*/backup/.*', line)
            or re.match('.*/upload/.*', line)
            or re.match('.*/image/.*', line)
            ):
                continue
        
        lineNumber += 1
        
        destinationWriter.write(line)
        if lineNumber == limit:
            fileIndex += 1
            destinationWriter.close()
            destinationWriter = open(workDirectory + destinationFileName + "_" + str(fileIndex)+".txt", 'a')
            lineNumber = 0
    
    destinationWriter.close()
    
def main():
    lineNumber = 0
    workDirectoryList = ["C:\\dev\\2016.11\\Windows\\Work\\Total\\02_Dir_D\\"
                     , "C:\\dev\\2016.11\\Windows\\Work\\Total\\03_Dir_Program Files\\"
                     , "C:\\dev\\2016.11\\Windows\\Work\\Total\\04_Dir_Program Files(x86)\\"]
    
    for workDirectory in workDirectoryList:
        mulit_open = Process(target=ExtractEffectiveData, args=(workDirectory, lineNumber))
        mulit_open.start()
    mulit_open.join()
        #ExtractEffectiveData(workDirectory, lineNumber)
    
if __name__ == '__main__':
    main()
    print 'Complete'