using System.Collections.Generic;
using System.Linq;

namespace UGF.Logs.Editor
{
    public class LogSettings
    {
        public bool Changed { get { return !m_defines.SequenceEqual(m_definesChanged); } }
        public bool LogInfo { get { return GetDefineSate(LogEditorUtility.DefineLogInfo); } set { SetDefineState(LogEditorUtility.DefineLogInfo, value); } }
        public bool LogWarning { get { return GetDefineSate(LogEditorUtility.DefineLogWarning); } set { SetDefineState(LogEditorUtility.DefineLogWarning, value); } }
        public bool LogError { get { return GetDefineSate(LogEditorUtility.DefineLogError); } set { SetDefineState(LogEditorUtility.DefineLogError, value); } }
        public bool LogException { get { return GetDefineSate(LogEditorUtility.DefineLogException); } set { SetDefineState(LogEditorUtility.DefineLogException, value); } }

        private readonly IEnumerable<string> m_defines;
        private readonly HashSet<string> m_definesChanged;

        public LogSettings(IEnumerable<string> defines)
        {
            m_defines = defines;
            m_definesChanged = new HashSet<string>(defines);
        }

        public void Reset()
        {
            m_definesChanged.Clear();

            foreach (string define in m_defines)
            {
                m_definesChanged.Add(define);
            }
        }

        public bool GetDefineSate(string define)
        {
            return m_definesChanged.Contains(define);
        }

        public void SetDefineState(string define, bool state)
        {
            if (state)
            {
                m_definesChanged.Add(define);
            }
            else
            {
                m_definesChanged.Remove(define);
            }
        }

        public IEnumerable<string> GetDefines()
        {
            return m_definesChanged.ToArray();
        }
    }
}
