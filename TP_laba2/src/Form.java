import java.awt.EventQueue;

import javax.swing.JFrame;

import java.awt.*;
import javax.swing.JTextField;
import javax.swing.JCheckBox;
import javax.swing.JLabel;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

public class Form {

	private JFrame frame;
	private JTextField textField;
	private JTextField textField_1;
	private JTextField textField_2;
	Color color;
	Color dopColor;
	int maxSpeed;
	int maxCountPassengers;
	int weight;
	private Transport inter;
	JButton button;
	JButton button_1;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Form window = new Form();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public Form() {
		initialize();
		color = new Color(0, 128, 0);
		dopColor = Color.WHITE;
		maxSpeed = 20;
		maxCountPassengers = 10;
		weight = 50;
		button.setBackground(color);
		button_1.setBackground(dopColor);
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.setBounds(100, 100, 670, 460);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(null);

		BoatPanel panel = new BoatPanel();
		panel.setBackground(Color.WHITE);
		panel.setBounds(10, 11, 634, 278);
		frame.getContentPane().add(panel);

		textField = new JTextField();
		textField.setText("150");
		textField.setBounds(146, 300, 44, 20);
		frame.getContentPane().add(textField);
		textField.setColumns(10);

		textField_1 = new JTextField();
		textField_1.setText("25");
		textField_1.setColumns(10);
		textField_1.setBounds(146, 325, 44, 20);
		frame.getContentPane().add(textField_1);

		textField_2 = new JTextField();
		textField_2.setText("1000");
		textField_2.setColumns(10);
		textField_2.setBounds(146, 350, 44, 20);
		frame.getContentPane().add(textField_2);

		JCheckBox chckbxNewCheckBox = new JCheckBox("\u041A\u0430\u0431\u0438\u043D\u0430");
		chckbxNewCheckBox.setBounds(216, 299, 97, 23);
		frame.getContentPane().add(chckbxNewCheckBox);

		JCheckBox checkBox = new JCheckBox("\u0412\u0438\u043D\u0442");
		checkBox.setBounds(216, 324, 97, 23);
		frame.getContentPane().add(checkBox);

		JLabel lblNewLabel = new JLabel(
				"\u041C\u0430\u043A\u0441\u0438\u043C\u0430\u043B\u044C\u043D\u0430\u044F \u0441\u043A\u043E\u0440\u043E\u0441\u0442\u044C");
		lblNewLabel.setBounds(10, 303, 136, 14);
		frame.getContentPane().add(lblNewLabel);

		JLabel label = new JLabel("\u041A\u043E\u043B-\u0432\u043E \u043F\u0430\u0441\u0441\u0430\u0436\u0438\u0440\u043E\u0432");
		label.setBounds(10, 328, 126, 14);
		frame.getContentPane().add(label);

		JLabel label_1 = new JLabel("\u041C\u0430\u0441\u0441\u0430");
		label_1.setBounds(10, 353, 52, 14);
		frame.getContentPane().add(label_1);

		JLabel label_3 = new JLabel("\u041E\u0441\u043D. \u0446\u0432\u0435\u0442");
		label_3.setBounds(369, 303, 61, 14);
		frame.getContentPane().add(label_3);

		JLabel label_4 = new JLabel("\u0414\u043E\u043F. \u0446\u0432\u0435\u0442");
		label_4.setBounds(369, 328, 61, 14);
		frame.getContentPane().add(label_4);

		JButton btnNewButton = new JButton("\u0414\u0432\u0438\u0436\u0435\u043D\u0438\u0435");
		btnNewButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (inter != null)
	            {
	                inter.moveVehicle();
					panel.updatePanel(inter);
	            }
			}
		});
		btnNewButton.setBounds(216, 349, 97, 23);
		frame.getContentPane().add(btnNewButton);

		button = new JButton("");
		button.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				ColorDialog colorD = new ColorDialog(frame, true, color);
				colorD.setVisible(true);
				color = colorD.getColor();
				button.setBackground(color);
			}
		});
		button.setBounds(440, 297, 52, 23);
		frame.getContentPane().add(button);

		button_1 = new JButton("");
		button_1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				ColorDialog colorD = new ColorDialog(frame, true, dopColor);
				colorD.setVisible(true);
				dopColor = colorD.getColor();
				button_1.setBackground(dopColor);
			}
		});
		button_1.setBounds(440, 322, 52, 23);
		frame.getContentPane().add(button_1);

		JButton button_2 = new JButton(
				"\u0417\u0430\u0434\u0430\u0442\u044C \u043B\u043E\u0434\u043A\u0443");
		button_2.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				dopColor = Color.YELLOW;
				button_1.setBackground(dopColor);
				inter = new Boat(maxSpeed, maxCountPassengers, weight, color);
				panel.updatePanel(inter);
			}
		});
		button_2.setBounds(369, 349, 210, 23);
		frame.getContentPane().add(button_2);

		JButton button_3 = new JButton(
				"\u0417\u0430\u0434\u0430\u0442\u044C \u043A\u0430\u0442\u0435\u0440");
		button_3.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if (dopColor == Color.YELLOW) {
					dopColor = Color.RED;
					button_1.setBackground(dopColor);
				}
				inter = new NewBoat(chckbxNewCheckBox.isSelected(), checkBox.isSelected(), maxSpeed, maxCountPassengers,
						weight, color, dopColor);
				panel.updatePanel(inter);
			}
		});
		button_3.setBounds(369, 374, 210, 23);
		frame.getContentPane().add(button_3);
	}
}
