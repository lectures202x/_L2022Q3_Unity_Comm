using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * �Ʒ��� System.IO.Ports�� ����ϱ� ���ؼ���
 * Unity Editor > Edit > Project Settings > Player > Other Settings > Configuration > Api Compatibility Level��
 * .NET 4.x�� �����ϰ� Unity Editor�� �ٽ� �����ؾ� �� * 
 */
using System.IO.Ports;

using System; // catch exception ó���� ���� ���

/*
Arduino Code
------------- 
int ledPin = 13;

void setup() {
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);
}

void loop() {
  if(Serial.available()){
    char c = Serial.read();
    Serial.print(c);

    int value = c - '0';
    if(c == '0' || c == '1'){
      digitalWrite(ledPin, value);
    }
  }
}
------------- 
*/

public class Serial_SimpleWrite : MonoBehaviour
{
    /// <summary>
    /// �ø��� ����� ����ϴ� arduino ��ü ����
    /// </summary>
    SerialPort arduino;

    /// <summary>
    /// �ø��� ��Ʈ
    /// </summary>
    public string portName = "COM5";

    /// <summary>
    /// �Ƶ��̳�� ������ �����͸� �����ϴ� sting ����
    /// </summary>
    public string serialOut;

    // Start is called before the first frame update
    void Start()
    {
        ///
        // PC�� Ȱ��ȭ�� �ø��� ��Ʈ�� ��� ����
        ///
        string[] ports = SerialPort.GetPortNames();

        ///
        // ports �迭 �ȿ� �ִ� �� ���(����, port)�� ���
        foreach (string port in ports)
        {
            print(port);
        }

        ///
        // arduino ��ü�� ��Ʈ �̸�, ��� �ӵ��� ���� �ʱ�ȭ
        ///
        arduino = new SerialPort(portName.ToString(), 9600);

        ///
        // arduino ��Ʈ ����
        ///
        arduino.Open();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnApplicationQuit()
    {
        arduino.Close();
    }

    public void SimpleWrite(string value)
    {
        print(value);
        arduino.WriteLine(value + "\n");
    }
}

