import java.awt.Color;
import java.awt.Graphics;

public class NewBoat extends Boat {
	private Color dopColor;
	private boolean kabina;
	private boolean vint;

	public NewBoat(boolean kabina, boolean vint, int maxSpeed, int maxCountPassengers, int weight,
			Color color, Color dopColor) {
		super(maxSpeed, maxCountPassengers, weight, color);
		this.dopColor = dopColor;
		this.vint = vint;
		this.kabina = kabina;
	}

	@Override
	protected void drawBoat(Graphics g) {
		if (kabina) {
			g.setColor(Color.RED);
			g.drawRect(startPosX, startPosY-20, 20,20);
		}
		if (vint) {
			g.setColor(Color.RED);
			g.drawLine(startPosX, startPosY, startPosX-10, startPosY-10);
			g.drawLine(startPosX, startPosY, startPosX-10, startPosY);
			g.drawLine(startPosX, startPosY, startPosX-10, startPosY+10);
		}
		
		super.drawBoat(g);
		if (dopColor != Color.BLACK) {
			g.setColor(dopColor);
			g.drawRect(startPosX, startPosY-20, 20,20);
		}
		
		
	}
}
