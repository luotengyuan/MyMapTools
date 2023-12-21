using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using System.Threading;

namespace MapToolsWinForm
{
    class NamedPipeClient
    {
        private NamedPipeClientStream clientStream;
        private string pipeName;
        private Thread connThread;
        private Thread recvThread;
        private int sleepTime = 100;
        // 声明回调函数原型，即函数委托了
        public delegate void OnDataRecv(string recvData);
        public OnDataRecv onDataRecv = null;

        public NamedPipeClient(string pipeName, OnDataRecv onDataRecv)
        {
            this.pipeName = pipeName;
            this.onDataRecv = onDataRecv;
            clientStream = new NamedPipeClientStream(pipeName);
            connThread = new Thread(ConnThreadTask);
            connThread.Start();
            recvThread = new Thread(RecvThreadTask);
            recvThread.Start();
        }

        private void ConnThreadTask(object obj)
        {
            while (true)
            {
                if (!clientStream.IsConnected)
                {
                    clientStream.Connect();
                    clientStream.ReadMode = PipeTransmissionMode.Message;
                }
                Thread.Sleep(sleepTime);
            }
        }

        private void RecvThreadTask(object obj)
        {
            while (true)
            {
                if (!clientStream.IsConnected)
                {
                    Thread.Sleep(sleepTime);
                    continue;
                }
                ReadMessage(clientStream);
                Thread.Sleep(sleepTime);
            }
        }

        private void ReadMessage(PipeStream s)
        {
            MemoryStream ms = new MemoryStream();
            byte[] buffer = new byte[0x1000]; // Read in 4 KB blocks
            do
            {
                ms.Write(buffer, 0, s.Read(buffer, 0, buffer.Length));
            }
            while (!s.IsMessageComplete);
            string str = Encoding.UTF8.GetString(ms.ToArray());
            if (onDataRecv != null)
            {
                onDataRecv(str);
            }
        }

        public void Close()
        {
            if (connThread != null && connThread.IsAlive)
            {
                connThread.Abort();
            }
            if (recvThread != null && recvThread.IsAlive)
            {
                recvThread.Abort();
            }
            clientStream.Dispose();
        }
    }
}
