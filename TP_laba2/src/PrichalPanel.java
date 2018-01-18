import java.awt.Graphics;

import javax.swing.JPanel;

public class PrichalPanel extends JPanel {
	private Prichal aquarium;
	
	public PrichalPanel(Prichal aq){
		updateAquariumPanel(aq);
	}
	
	public void updateAquariumPanel(Prichal aq){
		this.aquarium=aq;
		repaint();
	}
	
	@Override
	public void paint(Graphics g) {
		super.paint(g);
		aquarium.Draw(g);
	}
}
