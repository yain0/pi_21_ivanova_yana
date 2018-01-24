import java.awt.Color;
import java.awt.Graphics;
import java.util.ArrayList;

public class Prichal {

	ArrayList<ClassArray<Transport>> prichal;

	int countPlaces = 20;

	int placesSizeWidth = 210;
	int placesSizeHeight = 80;
	int currentLevel;

	public Prichal(int countStages) {
		prichal = new ArrayList<>();
		for (int i = 0; i < countStages; ++i) {
			prichal.add(new ClassArray<Transport>(countPlaces, null));
		}
	}

	public int getCurrentLevel() {
		return currentLevel;
	}

	public void setCurrentLevel(int currentLevel) {
		this.currentLevel = currentLevel;
	}

	public int PutBoatInPrichal(Transport boat) {
		return prichal.get(currentLevel).Add(boat);
	}

	public Transport GetBoatInPrichal(int ticket) {
		return prichal.get(currentLevel).Get(ticket);

	}

	public void Draw(Graphics g) {
		drawBoat(g);
		for (int i = 0; i < countPlaces; i++) {

			Transport boat = prichal.get(currentLevel).GetBoat(i);
			if (boat != null) {
				boat.setPosition(5 + i / 5 * placesSizeWidth + 15, i % 5 * placesSizeHeight + 30);
				boat.drawVehicle(g);
			}
		}

	}

	public void drawBoat(Graphics g) {

		g.setColor(Color.WHITE);

		g.fillRect(0, 0, (countPlaces / 5) * placesSizeWidth, 480);
		g.setColor(Color.black);
		for (int i = 0; i < countPlaces / 5; i++) {
			for (int j = 0; j < 6; ++j) {
				g.drawLine(i * placesSizeWidth, j * placesSizeHeight, i * placesSizeWidth + 110, j * placesSizeHeight);
			}
			g.drawLine(i * placesSizeWidth, 0, i * placesSizeWidth, 400);
		}
	}

}
