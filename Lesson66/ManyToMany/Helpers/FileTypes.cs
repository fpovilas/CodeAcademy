namespace ManyToMany.Helpers
{
    public class FileTypes
    {
        public class Music
        {
            public static readonly List<string> Types =
                [
                    "MP3",
                    "WAV",
                    "FLAC",
                    "AAC",
                    "OGG"
                ];
        }

        public class Document
        {
            public static readonly List<string> Types =
                [
                    "PDF",
                    "DOCX",
                    "XLSX",
                    "TXT",
                    "PPTX"
                ];
        }

        public class Picture
        {
            public static readonly List<string> Types =
                [
                    "JPG",
                    "PNG",
                    "GIF",
                    "BMP",
                    "TIFF"
                ];
        }

        public class Video
        {
            public static readonly List<string> Types =
                [
                    "MP4",
                    "AVI",
                    "MKV",
                    "MOV",
                    "WMV"
                ];
        }

        public class File
        {
            public static readonly List<string> Types =
                [
                    "ZIP",
                    "RAR",
                    "TAR",
                    "ISO",
                    "EXE"
                ];
        }
    }
}
