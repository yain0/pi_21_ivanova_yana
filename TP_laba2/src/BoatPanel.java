import java.awt.Graphics;

import javax.swing.JPanel;

public class BoatPanel extends JPanel {
	private Transport inter;

	public void updatePanel(Transport inter) {
		this.inter = inter;
		repaint();
	}

	@Override
	public void paint(Graphics g) {
		super.paint(g);
		if (inter != null) {
			inter.drawVehicle(g);
		}
	}
}
