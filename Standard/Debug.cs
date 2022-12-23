namespace CyberneticStudios.SOFramework
{
    [System.Serializable]
    public struct DebugInformation
    {
        public enum DebugLevel { INFO, WARNING, ERROR }

        public bool debugEnabled;
        public bool includeData;
        public string debugMessage;
        public DebugLevel debugLevel;
    }
}