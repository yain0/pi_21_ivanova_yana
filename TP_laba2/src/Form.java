import java.awt.*;
import javax.swing.*;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import javax.swing.border.BevelBorder;
import javax.swing.border.LineBorder;
import javax.swing.border.SoftBevelBorder;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;


public class Form {

	private Prichal prichal;

	private Color color;
	private Color dopColor;


	

	private JFrame frame;
	private JButton buttonColor;
	private JButton buttonDopColor;

	private JButton buttonLoc;
	private JButton buttonHeat;
	private JLabel lblNewLabel_1;
	private ReturnPanel returnPanel;
	private JPanel panel;
	private JLabel lblNewLabel;
	private JLabel lblDopcolor;
	
	private JTextField formattedTextField;
	private JPanel panelGet;
	private JButton buttonGet;
	private JPanel panel_1;
	private JList listBoxLevels;

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
		prichal= new Prichal(20);
		initialize();
		color = Color.GREEN.darker();
		dopColor = Color.GRAY.brighter();
		
		buttonColor.setBackground(color);
		buttonDopColor.setBackground(dopColor);

		
		listBoxLevels.setSelectedIndex(prichal.getCurrentLevel());
	}

	private void buttonLoc_Click() {
		Transport kut =new Boat( 7, 300, 300, color);
		int place = prichal.PutBoatInPrichal(kut);
		panel.repaint();
		JOptionPane.showMessageDialog(frame, "���� ����� " + place);
	}

	private void buttonHeat_Click() {
		Transport kut= new NewBoat(true,true,7,30,250,color,dopColor);
		int place = prichal.PutBoatInPrichal(kut);
		panel.repaint();
		JOptionPane.showMessageDialog(frame, "���� ����� " + place);
	}

	private void buttonGet_Click() {
		if (listBoxLevels.getSelectedIndex() < 0) {
			return;
		}
		try {
			Transport kut = prichal.GetBoatInPrichal(Integer.parseInt(formattedTextField.getText()));
			if (kut != null) {
				kut.setPosition(5, 5);
				returnPanel = new ReturnPanel(kut);
				returnPanel.setBackground(Color.WHITE);
				returnPanel.setBounds(10, 94, 139, 201);
				panelGet.add(returnPanel);
				
				panel.repaint();
			}
		}catch(Exception e){
			JOptionPane.showMessageDialog(frame, "���-�� ����� �� ���!");
		}

	}

	/**
	 * Initialize the contents of the frame.
	 */
	@SuppressWarnings({ "rawtypes", "unchecked" })
	private void initialize() {
		frame = new JFrame();
		frame.getContentPane().setBackground(UIManager.getColor("Button.background"));
		frame.getContentPane().setForeground(Color.BLACK);
		frame.setBounds(100, 100, 739, 508);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

		buttonLoc = new JButton("�����");
		buttonLoc.setBounds(291, 436, 122, 23);
		buttonLoc.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				buttonLoc_Click();
			}
		});

		buttonHeat = new JButton("�����");
		buttonHeat.setBounds(422, 437, 122, 23);
		buttonHeat.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				buttonHeat_Click();
			}
		});

		lblNewLabel = new JLabel("Color");
		lblNewLabel.setBounds(157, 405, 37, 14);

		lblDopcolor = new JLabel("dopColor");
		lblDopcolor.setBounds(282, 404, 63, 14);



		buttonColor = new JButton("");
		buttonColor.setBounds(204, 404, 68, 21);
		lblNewLabel.setLabelFor(buttonColor);

		buttonColor.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				color = JColorChooser.showDialog(frame, "Select a color", color);
				buttonColor.setBackground(color);
			}
		});

		buttonDopColor = new JButton("");
		buttonDopColor.setBounds(340, 404, 68, 21);
		lblDopcolor.setLabelFor(buttonDopColor);
		buttonDopColor.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				dopColor = JColorChooser.showDialog(frame, "Select a color", dopColor);
				buttonDopColor.setBackground(dopColor);
			}
		});


		panelGet = new JPanel();
		panelGet.setBounds(554, 153, 159, 306);
		panelGet.setBorder(new LineBorder(new Color(0, 0, 0)));
		panelGet.setToolTipText("");
		panelGet.setLayout(null);

		lblNewLabel_1 = new JLabel("������� �����");
		lblNewLabel_1.setBounds(10, 5, 139, 14);
		panelGet.add(lblNewLabel_1);


		formattedTextField = new JTextField();
		formattedTextField.setBounds(10, 29, 59, 20);
		panelGet.add(formattedTextField);

		buttonGet = new JButton("�������");
		buttonGet.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				buttonGet_Click();
			}
		});
		buttonGet.setBounds(10, 60, 111, 23);
		panelGet.add(buttonGet);
		
		panel_1 = new JPanel();
		panel_1.setBorder(new LineBorder(new Color(0, 0, 0)));
		panel_1.setBounds(554, 11, 159, 140);
		panel_1.setLayout(null);

		JLabel lblNewLabel_2 = new JLabel("\u0423\u0440\u043E\u0432\u043D\u0438:");
		lblNewLabel_2.setBounds(59, 5, 62, 14);
		panel_1.add(lblNewLabel_2);

		String[] elements = new String[5];
		for (int i = 0; i < 5; i++) {
			elements[i] = "Level" + (i+1);
		}
		listBoxLevels = new JList(elements);
		listBoxLevels.setBounds(10, 18, 139, 111);
		listBoxLevels.setLayoutOrientation(JList.VERTICAL);
		listBoxLevels.setVisibleRowCount(0);
		listBoxLevels.addListSelectionListener(new ListSelectionListener() {

			@Override
			public void valueChanged(ListSelectionEvent e) {
				prichal.setCurrentLevel(listBoxLevels.getSelectedIndex());
				panel.repaint();
			}

		});
		panel_1.add(listBoxLevels);
		
		panel = new PrichalPanel(prichal,listBoxLevels);
		panel.setBounds(10, 11, 534, 382);
		panel.setBorder(new SoftBevelBorder(BevelBorder.RAISED, null, null, null, null));
		panel.setBackground(Color.WHITE);
		
		frame.getContentPane().setLayout(null);
		frame.getContentPane().add(panel);
		frame.getContentPane().add(buttonLoc);
		frame.getContentPane().add(buttonHeat);
		frame.getContentPane().add(panelGet);
		frame.getContentPane().add(lblNewLabel);
		frame.getContentPane().add(buttonColor);
		frame.getContentPane().add(buttonDopColor);
		frame.getContentPane().add(lblDopcolor);
		frame.getContentPane().add(panel_1);
	}
}
