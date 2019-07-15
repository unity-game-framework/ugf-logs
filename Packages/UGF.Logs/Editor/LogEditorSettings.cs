using System.Collections.Generic;
using System.Linq;

namespace UGF.Logs.Editor
{
    /// <summary>
    /// Represents local settings of the logs.
    /// </summary>
    public class LogEditorSettings
    {
        /// <summary>
        /// Gets the value that determines whether settings are changed and not applied.
        /// </summary>
        public bool Changed { get { return !m_defines.SequenceEqual(m_definesChanged); } }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_INFO' define is specified.
        /// </summary>
        public bool LogInfo { get { return GetDefineSate(LogEditorUtility.DefineLogInfo); } set { SetDefineState(LogEditorUtility.DefineLogInfo, value); } }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_WARNING' define is specified.
        /// </summary>
        public bool LogWarning { get { return GetDefineSate(LogEditorUtility.DefineLogWarning); } set { SetDefineState(LogEditorUtility.DefineLogWarning, value); } }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_ERROR' define is specified.
        /// </summary>
        public bool LogError { get { return GetDefineSate(LogEditorUtility.DefineLogError); } set { SetDefineState(LogEditorUtility.DefineLogError, value); } }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_EXCEPTION' define is specified.
        /// </summary>
        public bool LogException { get { return GetDefineSate(LogEditorUtility.DefineLogException); } set { SetDefineState(LogEditorUtility.DefineLogException, value); } }

        private readonly HashSet<string> m_defines;
        private readonly HashSet<string> m_definesChanged;

        /// <summary>
        /// Creates logs settings with the specified defines of the project.
        /// </summary>
        /// <param name="defines">The defines of the project.</param>
        public LogEditorSettings(IEnumerable<string> defines)
        {
            m_defines = new HashSet<string>(defines);
            m_definesChanged = new HashSet<string>(defines);
        }

        /// <summary>
        /// Reverts all changes.
        /// </summary>
        public void Revert()
        {
            m_definesChanged.Clear();

            foreach (string define in m_defines)
            {
                m_definesChanged.Add(define);
            }
        }

        /// <summary>
        /// Applies all changes.
        /// </summary>
        public void Apply()
        {
            m_defines.Clear();

            foreach (string define in m_definesChanged)
            {
                m_defines.Add(define);
            }
        }

        /// <summary>
        /// Gets the value that determines whether the specified define is specified.
        /// </summary>
        /// <param name="define">The define to check.</param>
        public bool GetDefineSate(string define)
        {
            return m_definesChanged.Contains(define);
        }

        /// <summary>
        /// Sets the state of the specified define.
        /// </summary>
        /// <param name="define">The define.</param>
        /// <param name="state">The value determines whether the specified define is active.</param>
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

        /// <summary>
        /// Gets the applied defines.
        /// </summary>
        public IEnumerable<string> GetDefines()
        {
            return m_defines.ToArray();
        }
    }
}
