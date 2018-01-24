import java.awt.Color;
import java.awt.Graphics;

public class Prichal {
	ClassArray<Transport> prichal;
	int countPlaces = 20;

    int placeSizeWidth = 210;
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
				boat.setPosition(5 + i / 5 * placeSizeWidth + 15, i % 5 * placeSizeHeight + 30);
				boat.drawVehicle(g);
			}
		}
	}

	public void drawPrichal(Graphics g) {
	       
        g.setColor(Color.WHITE);

        g.fillRect(0, 0, (countPlaces / 5) * placeSizeWidth, 480);
        g.setColor(Color.black);
        for (int i=0;i<countPlaces/5;i++) {
            for (int j=0;j<6;++j) {
                g.drawLine(i * placeSizeWidth, j * placeSizeHeight, i * placeSizeWidth + 110, j * placeSizeHeight);
            }
            g.drawLine(i*placeSizeWidth,0,i*placeSizeWidth,400);
        
    }
	}
}
