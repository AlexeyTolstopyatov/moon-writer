#load "MoonObjects.fs"
#load "MoonDocument.fs"

open MoonDocument

let x = MoonDocument.MoonDocument()

x.Name = "moonDocument"

let cont = 
    x.createComment("Elements") +
    x.createElement(MoonElement("title", "Properties")) + 
    x.createElement(MoonElement("text", $"Property list of {x.Name}")) +
    x.createElement(MoonElement("color", "#1c1c1c")) + 
    x.createComment("Lists") + 
    x.createList(MoonList("integers", [|"int8";"int16";"int32";"int64"|])) + 
    x.createList(MoonList("floats", [|"Single";"Double";"Decimal"|]))


printf "%s", cont

x = MoonDocument(
    name="moonDocument", 
    content=MoonSet(
        name="etree",
        lists=[
            MoonList("integers", [|"int8";"int16";"int32";"int64"|])
            MoonList("floatings", [|"Single";"Double";"Decimal"|])
        ],
        elements=[
            MoonElement("title", "MoonDocument");
            MoonElement("text","Property list")
        ]
    ))

x.save("C:\\")