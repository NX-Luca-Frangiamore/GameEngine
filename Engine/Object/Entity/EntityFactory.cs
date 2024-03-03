using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace GameEngine.Object.Entity;
public class EntityFactory
{
    public static Entity CreateEntity(Point2 position,DtoCreateEntity dto)
    {
        int xD = dto.Rows.Select(x => x.Els.Count).Max();
        int yD = dto.Rows.Count;
        Point2 dimension = new(xD,yD);
        Entity entity = new(dimension, position);
        for(int y=0;y<yD;y++) { 
            for(int x=0; x< xD; x++)
            {
                Pixel pixel;
                if (dto.Ins.TryGetValue(new Point2(x, y),out var v))
                    pixel = new Pixel(dto.Rows[y].Els[x], v);
                pixel = new Pixel(dto.Rows[y].Els[x], v);
                if (!String.IsNullOrEmpty(dto.Rows[y].Els[x]))
                {
                    entity.Sprite.Data.SetPixel(new(x, y), pixel);
                    entity.Body.Data.SetElement(new(x, y),true);
                }
            }
        }
        return entity;
    }
}
