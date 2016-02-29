using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniDSL.DSL.Objects;

namespace MiniDSL.Objects {

	public class ShowObject : MiniDSLObject {

		public ShowObject ( ConditionObjectFactory factory )
			: base ( MiniDSLObjectType.Property , factory ) {

			InnerObjects.Add ( "наконсоли" , new ConsoleObject (factory) );
		}

	}

}
