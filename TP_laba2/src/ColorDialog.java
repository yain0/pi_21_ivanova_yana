import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.event.*;

public class ColorDialog extends JDialog {
	private int redValue, greenValue, blueValue;
	private Color color = null;

	private JSlider jslRed = new JSlider(0, 255);
	private JSlider jslGreen = new JSlider(0, 255);
	private JSlider jslBlue = new JSlider(0, 255);

	private JButton jbtOK = new JButton("OK");
	private JButton jbtCancel = new JButton("Cancel");

	private JPanel jpSelectedColor = new JPanel();

	public ColorDialog(java.awt.Frame parent, boolean modal, Color colorD) {
		super(parent, modal);
		setTitle("Choose Color");
		redValue = colorD.getRed();
		greenValue = colorD.getGreen();
		blueValue = colorD.getBlue();
		jslRed.setValue(redValue);
		jslGreen.setValue(greenValue);
		jslBlue.setValue(blueValue);
		color = new Color(redValue, greenValue, blueValue);
		jpSelectedColor.setBackground(color);

		JPanel jpButtons = new JPanel();
		jpButtons.add(jbtOK);
		jpButtons.add(jbtCancel);

		JPanel jpLabels = new JPanel();
		jpLabels.setLayout(new GridLayout(3, 0));
		jpLabels.add(new JLabel("Red"));
		jpLabels.add(new JLabel("Green"));
		jpLabels.add(new JLabel("Blue"));

		JPanel jpSliders = new JPanel();
		jpSliders.setLayout(new GridLayout(3, 0));
		jpSliders.add(jslRed);
		jpSliders.add(jslGreen);
		jpSliders.add(jslBlue);

		JPanel jpSelectColor = new JPanel();
		jpSelectColor.setLayout(new BorderLayout());
		jpSelectColor.setBorder(BorderFactory.createTitledBorder("Select Color"));
		jpSelectColor.add(jpLabels, BorderLayout.WEST);
		jpSelectColor.add(jpSliders, BorderLayout.CENTER);

		JPanel jpColor = new JPanel();
		jpColor.setLayout(new BorderLayout());
		jpColor.add(jpSelectColor, BorderLayout.SOUTH);
		jpColor.add(jpSelectedColor, BorderLayout.CENTER);
		jpColor.repaint();

		add(jpButtons, BorderLayout.SOUTH);
		add(jpColor, BorderLayout.CENTER);
		pack();

		jbtOK.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				setVisible(false);
			}
		});

		jbtCancel.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				color = colorD;
				setVisible(false);
			}
		});

		jslRed.addChangeListener(new ChangeListener() {
			@Override
			public void stateChanged(ChangeEvent e) {
				redValue = jslRed.getValue();
				color = new Color(redValue, greenValue, blueValue);
				jpSelectedColor.setBackground(color);
			}
		});

		jslGreen.addChangeListener(new ChangeListener() {
			@Override
			public void stateChanged(ChangeEvent e) {
				greenValue = jslGreen.getValue();
				color = new Color(redValue, greenValue, blueValue);
				jpSelectedColor.setBackground(color);
			}
		});

		jslBlue.addChangeListener(new ChangeListener() {
			@Override
			public void stateChanged(ChangeEvent e) {
				blueValue = jslBlue.getValue();
				color = new Color(redValue, greenValue, blueValue);
				jpSelectedColor.setBackground(color);
			}
		});
	}

	@Override
	public Dimension getPreferredSize() {
		return new java.awt.Dimension(200, 200);
	}

	public Color getColor() {
		return color;
	}
}
