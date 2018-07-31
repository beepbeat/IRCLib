﻿using System;
using IRClib.Definitions;

namespace IRClib.util {
    public class Events {
        public class RawMessageEventArgs : EventArgs {
            private readonly string message;
            private readonly Connection connection;

            public RawMessageEventArgs(string message, Connection connection) {
                this.message = message;
                this.connection = connection;
            }

            public string Message {
                get { return message; }
            }

            public Connection Connection {
                get { return connection; }
            }
        }
        public class MessageEventArgs : EventArgs {
            private readonly Message message;

            public MessageEventArgs(Message message) {
                this.message = message;
            }

            public Message GetMessage() {
                return message;
            }
        }
        public class StringEventArgs : EventArgs {
            private readonly string _string;

            public StringEventArgs(string String) {
                this._string = String;
            }

            public string GetString() {
                return _string;
            }
        }
        
        public static event EventHandler<MessageEventArgs> Message;
        public static event EventHandler<RawMessageEventArgs> RawMessage;
        public static event EventHandler<StringEventArgs> NumericEvent;

        public void OnMessage(MessageEventArgs args) {
            if (Message != null) Message(this, args);
        }

        public void OnRawMessage(RawMessageEventArgs args) {
            if (RawMessage != null) RawMessage(this, args);
        }

        public void OnNumericEvent(StringEventArgs args) {
            if (NumericEvent != null) NumericEvent(this, args);
        }
    }
}