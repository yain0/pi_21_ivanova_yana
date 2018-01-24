import java.awt.Graphics;
import java.awt.Panel;

public class ReturnPanel extends Panel {
	Transport boat;
	public ReturnPanel(Transport boat){
		this.boat=boat;
	}
	
	public void paint(Graphics g) {
		super.paint(g);
		boat(g,boat);
	

	}
	public void boat(Graphics g,Transport boat){
		if (boat!=null){
		boat.drawVehicle(g);
		}
	}
}
