using System;
using UnityEngine;

namespace UGF.Logs.Editor
{
    [Serializable]
    public struct LogBuildSettings
    {
        [SerializeField] private bool m_info;
        [SerializeField] private bool m_debug;
        [SerializeField] private bool m_warning;
        [SerializeField] private bool m_error;
        [SerializeField] private bool m_exception;

        public bool Info { get { return m_info; } set { m_info = value; } }
        public bool Debug { get { return m_debug; } set { m_debug = value; } }
        public bool Warning { get { return m_warning; } set { m_warning = value; } }
        public bool Error { get { return m_error; } set { m_error = value; } }
        public bool Exception { get { return m_exception; } set { m_exception = value; } }
    }
}
