using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace GameEngine.Object.Entity;
public class DtoCreateEntity(int y)
{
    public Dictionary<Point2, InfoPixel> Ins { get; internal set; } = new();

    public List<DtoCreateRow> Rows = new(y);
    public class DtoCreateRow(int x)
    {
        public List<string?> Els=new(x);

    }
    public void SetInfo(Point2 position, InfoPixel infoPixel) =>Ins[position]=infoPixel;

}

