using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    internal class ModeManager
    {
        public class Mode
        {
            public Form1 f1;
            public Mode(Form1 f1)
            {
                this.f1 = f1;
            }

            public virtual void DoSmth(object sender, MouseEventArgs e) { }
            public virtual void Apply(object sender, EventArgs e) { }

        }
        public class MTask1 : Mode
        {
            public MTask1(Form1 f1) : base(f1) { }
            public override void DoSmth(object sender, MouseEventArgs e)
            {
                f1?.CreatePoly(sender, e);
            }
        }
        public class MTask31 : Mode
        {
            public MTask31(Form1 f1) : base(f1) { }
            public override void DoSmth(object sender, MouseEventArgs e)
            {
                f1?.MovePoly(sender, e);
            }
            public override void Apply(object sender, EventArgs e)
            {
                f1?.ApplyMovePoly(sender, e);
            }
        }
        public class MTask32 : Mode
        {
            public MTask32(Form1 f1) : base(f1) { }
            public override void DoSmth(object sender, MouseEventArgs e)
            {
                f1?.SetPoint(sender, e);
            }
            public override void Apply(object sender, EventArgs e)
            {
                f1?.ApplyPointRotate(sender, e);
            }
        }
        public class MTask33 : Mode
        {
            public MTask33(Form1 f1) : base(f1) { }
            public override void DoSmth(object sender, MouseEventArgs e)
            {
                f1?.CenterRotate(sender, e);
            }
            public override void Apply(object sender, EventArgs e)
            {
                f1?.ApplyCenterRotate(sender, e);
            }
        }
        public class MTask34 : Mode
        {
            public MTask34(Form1 f1) : base(f1) { }
            public override void DoSmth(object sender, MouseEventArgs e)
            {
                f1?.PointScale(sender, e);
            }
            public override void Apply(object sender, EventArgs e)
            {
                f1?.ApplyPointScale(sender, e);
            }
        }
        public class MTask35 : Mode
        {
            public MTask35(Form1 f1) : base(f1) { }
            public override void DoSmth(object sender, MouseEventArgs e)
            {
                f1?.CenterScale(sender, e);
            }
            public override void Apply(object sender, EventArgs e)
            {
                f1?.ApplyCenterScale(sender, e);
            }
        }
        public class MTask4 : Mode
        {
            public MTask4(Form1 f1) : base(f1) { }
            public override void DoSmth(object sender, MouseEventArgs e)
            {
                f1?.FindPoint(sender, e);
            }
        }
        public class MTask5 : Mode
        {
            public MTask5(Form1 f1) : base(f1) { }
            public override void DoSmth(object sender, MouseEventArgs e)
            {
                f1?.Check(sender, e);
            }
            public override void Apply(object sender, EventArgs e)
            {
                f1?.ApplyCheck(sender, e);
            }
        }
        public class MTask6 : Mode
        {
            public MTask6(Form1 f1) : base(f1) { }
            public override void DoSmth(object sender, MouseEventArgs e)
            {
                f1?.Classification(sender, e);
            }
        }


    }
}
