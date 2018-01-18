import java.awt.*;

public class Boat extends Vehicle {

	public Boat(int maxSpeed, int maxCountPassengers, int weight, Color color) {
		setMaxSpeed(maxSpeed);
		setMaxCountPassengers(maxCountPassengers);
		setColorBody(color);
		setWeight(weight);
		countPassengers = 0;

		startPosX = 75;
		startPosY = 90;
	}

	@Override
	protected void setMaxSpeed(int value) {
		if (value > 0 && value < 300) {
			super.setMaxSpeed(value);
		} else {
			super.setMaxSpeed(150);
		}
	}
	@Override
	protected void setMaxCountPassengers(int value) {
		if (value > 0 && value < 16) {
			super.setMaxCountPassengers(value);
		} else {
			super.setMaxCountPassengers(15);
		}
	}

	

	@Override
	public void setWeight(int value) {
		if (value > 500 && value < 1500) {
			super.setWeight(value);
		} else {
			super.setWeight(1000);
		}
	}

	

	
	@Override
	public void moveVehicle() {
		startPosX += (int) (getMaxSpeed() * 50 / getWeight() / (countPassengers == 0 ? 1 : countPassengers));
	}

	@Override
	public void drawVehicle(Graphics g) {
		drawBoat(g);
	}

	protected void drawBoat(Graphics g) {
g.setColor(getColorBody());
		
		int x = startPosX;
		int y = startPosY;
		int[] xPoints = new int[] { x, x + 60, x + 40, x, x };
		int[] yPoints = new int[] { y, y, y + 20, y + 20, y };
		g.fillPolygon(xPoints, yPoints, xPoints.length);

	}

	

}
