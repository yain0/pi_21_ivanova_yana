import java.awt.Color;
import java.awt.Graphics;

public class Prichal {
	ClassArray<Transport> prichal;
	int countPlaces = 8;
	int placeSizeWidth = 300;
	int placeSizeHeight = 80;

	public Prichal() {
		prichal = new ClassArray<Transport>(countPlaces, null);
	}

	public int PutNewBoatInPrichal(Transport boat) {
		return prichal.add(prichal, boat);
	}

	public Transport GetNewBoatFromPrichal(int index) {
		return prichal.dec(prichal, index);
	}

	public void Draw(Graphics g) {
		drawPrichal(g);
		for (int i = 0; i < countPlaces; i++) {
			Transport boat = prichal.getObject(i);
			if (boat != null) {
				boat.setPosition(50 + i / 4 * (placeSizeWidth + 10) + 5, i % 4 * (placeSizeHeight + 20) + 45);
				boat.drawVehicle(g);
			}
		}
	}

	private void drawPrichal(Graphics g) {
		for (int i = 0; i < countPlaces / 4; i++) {
			for (int j = 0; j < 4; j++) {
				g.setColor(Color.BLUE);
				g.fillRect(10 * (i + 1) + i * placeSizeWidth, 20 * (j + 1) + j * placeSizeHeight, placeSizeWidth,
						placeSizeHeight);
				g.setColor(Color.BLACK);
				g.drawRect(10 * (i + 1) + i * placeSizeWidth, 20 * (j + 1) + j * placeSizeHeight, placeSizeWidth,
						placeSizeHeight);
			}
		}
	}
}
