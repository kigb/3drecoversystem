using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class TcpTest : MonoBehaviour
{
    TcpListener server;
    TcpClient client;
    Thread serverThread;
    public bool moving;

    public int speed;
    // 服务器的IP地址和端口
    string serverIP = "192.168.1.185"; // 修改为实际服务器的IP地址
    int port = 12345; // 设置端口号，与客户端相同

    void Start()
    {
        IPAddress ipAddress = IPAddress.Parse(serverIP);
        server = new TcpListener(ipAddress, port);
        server.Start();

        Debug.Log($"Server listening on {serverIP}:{port}");

        // 启动一个线程等待客户端连接
        serverThread = new Thread(new ThreadStart(WaitForClient));
        serverThread.Start();
    }

    void WaitForClient()
    {
        while (true)
        {
            // 等待客户端连接
            client = server.AcceptTcpClient();
            Debug.Log("Client connected!");

            // 开始处理这个客户端的数据
            HandleClient(client);
        }
    }

    void HandleClient(TcpClient tcpClient)
    {
        NetworkStream stream = tcpClient.GetStream();

        byte[] buffer = new byte[1024];
        int bytesRead = 0;

        try
        {
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                if (!string.IsNullOrEmpty(receivedMessage))
                {
                    if (int.TryParse(receivedMessage, out int integerValue))
                    {
                        moving = true;
                        speed = integerValue;
                        Debug.Log($"Received message: {receivedMessage}");
                    }
                    else
                    {
                        moving=false;
                        Debug.Log($"Received invalid message: {receivedMessage}");
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log($"Error reading data: {e.Message}");
        }
        finally
        {
            tcpClient.Close();
            Debug.Log("Client disconnected.");
        }
    }

    void OnDestroy()
    {
        // 关闭服务器和线程
        server.Stop();
        if (serverThread != null && serverThread.IsAlive)
        {
            serverThread.Abort();
        }
    }
}
