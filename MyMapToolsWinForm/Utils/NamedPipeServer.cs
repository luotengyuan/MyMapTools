using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using System.Threading;

namespace MapToolsWinForm
{
    /// <summary>
    /// Windows命名管道服务类
    /// </summary>
    class NamedPipeServer
    {
        private NamedPipeServerStream serverStream;
        private string pipeName;
        private Thread connThread;
        private Thread sendThread;
        private int sleepTime = 10;

        public NamedPipeServer(string pipeName)
        {
            this.pipeName = pipeName;
            serverStream = new NamedPipeServerStream(pipeName, PipeDirection.InOut, 254, PipeTransmissionMode.Message);
            connThread = new Thread(ConnThreadTask);
            connThread.Start();
            sendThread = new Thread(SendThreadTask);
            sendThread.Start();
        }

        private void ConnThreadTask(object obj)
        {
            while (true)
            {
                if (!serverStream.IsConnected)
                {
                    try
                    {
                        serverStream.WaitForConnection();
                        sendQueue.Clear();
                    }
                    catch (Exception)
                    {
                        serverStream.Disconnect();
                        serverStream.Dispose();
                        serverStream = new NamedPipeServerStream(pipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Message);
                    }
                }
                Thread.Sleep(sleepTime);
            }
        }

        Queue<string> sendQueue = new Queue<string>();
        private void SendThreadTask(object obj)
        {
            while (true)
            {
                try
                {
                    if (!serverStream.IsConnected)
                    {
                        Thread.Sleep(sleepTime);
                        continue;
                    }
                    if (sendQueue.Count <= 0)
                    {
                        Thread.Sleep(sleepTime);
                        continue;
                    }
                    string send_str = sendQueue.Dequeue();
                    byte[] byteArr = Encoding.UTF8.GetBytes(send_str);
                    serverStream.Write(byteArr, 0, byteArr.Length);
                    serverStream.Flush();
                    Thread.Sleep(sleepTime);
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        public bool sendCanData(string send_str)
        {
            if (!serverStream.IsConnected)
            {
                return false;
            }
            lock (sendQueue)
            {
                if (sendQueue.Count > 20)
                {
                    sendQueue.Clear();
                }
                sendQueue.Enqueue(send_str);
            }
            return true;
        }

        public void Close()
        {
            if (connThread != null && connThread.IsAlive)
            {
                connThread.Abort();
            }
            if (sendThread != null && sendThread.IsAlive)
            {
                sendThread.Abort();
            }
            if (sendQueue != null && sendQueue.Count > 0)
            {
                sendQueue.Clear();
            }
            try
            {
                serverStream.Disconnect();
                serverStream.Dispose();
            }
            catch (Exception)
            {
            }
        }
    }
}
