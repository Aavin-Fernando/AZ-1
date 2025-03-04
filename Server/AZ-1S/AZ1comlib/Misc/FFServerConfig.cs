using System;
using Godot;
using static Godot.StringExtensions;

public struct FFServerConfig {
        public FFServerConfig() {}

        public Vector3G SpawnChunk { get; set; } = new Vector3G(0,0,0,0f,0f,0f);
        public DataDirEnum DataDir = DataDirEnum.kExecutableDir;
        public string DataDirPath {
            get { switch (DataDir){
                case DataDirEnum.kGDUserDir:    return "user://";
                case DataDirEnum.kCustomDir:    return _DataDirPath;
                case DataDirEnum.kExecutableDir: default: 
                    return OS.GetExecutablePath().GetBaseDir();
            }
            }
            set { DataDir = DataDirEnum.kCustomDir; _DataDirPath = value; }
        }

        public uint WorldSeed { set { _WorldSeed = value; } 
        get { 
            if (_WorldSeed != default(uint)) {
                return _WorldSeed;
            } else {
                var rng = new RandomNumberGenerator();
		        rng.Randomize();
                _WorldSeed = rng.Randi();
                return _WorldSeed;
            }
        }}








        private uint _WorldSeed = default(uint);
        private string _DataDirPath = "";

        public enum DataDirEnum { kExecutableDir, kGDUserDir, kCustomDir};
} 