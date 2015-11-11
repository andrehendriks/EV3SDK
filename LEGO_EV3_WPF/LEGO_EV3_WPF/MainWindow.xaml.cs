using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lego.Ev3.Desktop;
using Lego.Ev3.Core;

namespace LEGO_EV3_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Brick brick = new Brick(new BluetoothCommunication("COM46"));
        
        public MainWindow()
        {
            
           
            brick.Ports[InputPort.Four].SetMode(InfraredMode.Proximity);
            
            InitializeComponent();
        }

        private void async1()
        {
            brick.ConnectAsync();
        }

        private void async2()
        {
            brick.Disconnect();
        }

        private async void BatchCommand()
        {
            brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.B, 50, 1000, false);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.C, 50, 1000, false);
            await brick.BatchCommand.SendCommandAsync();
        }

        private async void BatchCommand2()
        {
            brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.B, -50, 1000, false);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.C, 50, 1000, false);
            await brick.BatchCommand.SendCommandAsync();
        }

        private async void BatchCommand3()
        {
            brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.B, 50, 1000, false);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.C, -50, 1000, false);
            await brick.BatchCommand.SendCommandAsync();
        }

        private async void BatchCommand4()
        {
            brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.B, -50, 1000, false);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.C, -50, 1000, false);
            await brick.BatchCommand.SendCommandAsync();
        }

        private async void BatchCommand5()
        {
            brick.BatchCommand.StepMotorAtSpeed(OutputPort.B, 0, 100, false);
            brick.BatchCommand.StepMotorAtSpeed(OutputPort.C, 0, 100, false);
            await brick.BatchCommand.SendCommandAsync();
        }
        

        

        

        

        

        private void button_left_Click(object sender, RoutedEventArgs e)
        {
            BatchCommand2();
        }

        private void button_forward_Click(object sender, RoutedEventArgs e)
        {
            BatchCommand();
        }

        private void button_right_Click(object sender, RoutedEventArgs e)
        {
            BatchCommand3();
        }

        private void button_backward_Click(object sender, RoutedEventArgs e)
        {
            BatchCommand4();
        }

        private void button_stop_Click(object sender, RoutedEventArgs e)
        {
            BatchCommand5();
        }

        private void button_connect_Click(object sender, RoutedEventArgs e)
        {
            async1();
        }

        private void button_disconnect_Click(object sender, RoutedEventArgs e)
        {
            async2();
        }
    }
}
