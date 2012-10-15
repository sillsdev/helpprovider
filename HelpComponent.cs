using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;

namespace Vulcan.Uczniowie.HelpProvider
{
    public class HelpComponent : System.ComponentModel.Component, IMessageFilter
    {
		#region Component
        public enum ProviderMode { Client, Builder };

		private System.ComponentModel.Container components = null;

		public HelpComponent(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

        public HelpComponent()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
					components.Dispose();

                Application.RemoveMessageFilter( this );
			}
			base.Dispose( disposing );
		}


		#region Component Designer generated code
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();

            // dodaj globalny filtr komunikatów
            try
            {
                Application.AddMessageFilter( this );
            }
            catch {}
		}
		#endregion
        #endregion

        #region HelperProcessor
        public  ProviderMode Mode;
        private IHelpProcessor helpProcessor;
        public  IHelpProcessor HelpProcessor
        {
            get
            {
                switch ( Mode )
                {
                    case ProviderMode.Client :
                        if ( helpProcessor == null ||
                             helpProcessor.GetType() != typeof( ClientHelpProcessor )
                            )
                            helpProcessor = new ClientHelpProcessor();
                        break;
                    case ProviderMode.Builder :
                        if ( helpProcessor == null ||
                             helpProcessor.GetType() != typeof( BuilderHelpProcessor )
                            )
                            helpProcessor = new BuilderHelpProcessor();
                        break;
                }

                return helpProcessor;
            }
        }
        #endregion

        #region Builder mode predicate
        public delegate bool BuilderModeDelegate();

        public BuilderModeDelegate BuilderModePredicate =
            new BuilderModeDelegate( DefaultBuilderModePredicate );

        private static bool DefaultBuilderModePredicate()
        {
            return
                Control.ModifierKeys == Keys.Control &&
                System.Environment.CommandLine.ToLower().Contains( "helpbuilder" );
        }
        #endregion

        #region IMessageFilter Members
        public bool PreFilterMessage( ref Message m )
        {
            switch ( m.Msg )
            {
                case 0x100: // WM_KEYDOWN
                    if ( (int)m.WParam == (int)Keys.F1 )
                    {
                        try
                        {
                            if ( BuilderModePredicate() )
                                Mode = ProviderMode.Builder;
                            else
                                Mode = ProviderMode.Client;

                            ProcessRequest( m.HWnd );
                            return true;
                        }
                        catch { }
                    }
                    break;
            }
            return false;
        }
        #endregion

        #region HelpProcessing
        private void ProcessRequest( IntPtr hWND )
        {
            Control NetControl = ControlFromHandle( hWND );
            if ( NetControl != null && HelpProcessor != null
                )
                HelpProcessor.ProcessControlHelp( NetControl );
        }
        #endregion

        #region ControlFromHandle
        private Control ControlFromHandle( IntPtr hWND )
        {
            while ( hWND != IntPtr.Zero )
            {
                Control control = Control.FromHandle( hWND );
                if ( control != null )
                    return control;

                hWND = GetParent( hWND );
            }

            return null;
        }

        [DllImport( "user32.dll", ExactSpelling = true, CharSet = CharSet.Auto )]
        public static extern IntPtr GetParent( IntPtr hWnd );
        #endregion

        public bool FoundHelpMapping
        {
            get { return ResourceHelper.HelpDescriptions.TopicDescription.Count > 0; }
        }

        public string HelpFilePath
        {
            get
            {
                if (!FoundHelpMapping)
                {
                    return "";
                }
                return ResourceHelper.HelpDescriptions.HelpFilePath;
            }
        }

        public void RegisterHelpFileMapping(string helpFileMapping)
        {

        }
    }
}
