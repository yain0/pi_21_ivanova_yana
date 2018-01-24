import java.awt.Graphics;

import javax.swing.JList;
import javax.swing.JPanel;

public class PrichalPanel extends JPanel {
	private Prichal prichal;
	JList listBoxLevels;
	
	public PrichalPanel(Prichal pr){
		updatePrichalPanel(pr);
	}
	
	public void updatePrichalPanel(Prichal pr){
		this.prichal=pr;
		repaint();
	}
	public PrichalPanel(Prichal prichal, JList listBoxLevels) {
		this.prichal = prichal;
		this.listBoxLevels = listBoxLevels;
	}
	@Override
	public void paint(Graphics g) {
		super.paint(g);
		prichal.Draw(g);
	}
}
