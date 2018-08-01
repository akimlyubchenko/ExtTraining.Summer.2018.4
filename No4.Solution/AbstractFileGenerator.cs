using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No4.Solution
{
    abstract class AbstractFileGenerator
    {
        public string WorkingDirectory;

        public string FileExtension;
        public delegate byte[] RandomGenerator(Type type, int contentLength, RandomGenerator del);

        public void GenerateFiles(int filesCount, int contentLength, RandomGenerator del)
        {
            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = this.GenerateFileContent(contentLength, del);

                var generatedFileName = $"{Guid.NewGuid()}{this.FileExtension}";

                this.WriteBytesToFile(generatedFileName, generatedFileContent);
            }
        }

        public byte[] GenerateFileContent(int contentLength, RandomGenerator del)
            => del.Invoke(this.GetType(), contentLength, del);

        private void WriteBytesToFile(string fileName, byte[] content)
        {
            if (!Directory.Exists(WorkingDirectory))
            {
                Directory.CreateDirectory(WorkingDirectory);
            }

            File.WriteAllBytes($"{WorkingDirectory}//{fileName}", content);
        }
    }
}
