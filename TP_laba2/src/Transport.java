import java.awt.Color;
import java.awt.Graphics;

public interface Transport {
	void moveVehicle();

	void drawVehicle(Graphics g);

	void setPosition(int x, int y);

	void loadPassenger(int count);

	int getPassenger();

	void setMainColor(Color color);
}

