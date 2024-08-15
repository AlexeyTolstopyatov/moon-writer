namespace MoonDocument

// schizophrenic notes...
// 
// var document = new MnDocument()
// document.Name = "My object-oriented document";
// document.Container = new List<MnObject> {
//      new MnObject() {Name = "arraySegment", Content = new object[]{"", "", "", ""}},
//      new MnObject() {Name = "setSegment", Content = new MnObject[]{new MnObject(){Name = "", Content = ""}}},
//      new MnObject() {Name = "element", Content = MnObject[] {Name = "", Content = ""}}
// }
// 
// document = new MnDocument()
// document.Name = "my oo-notation"
// document.Container.Add(new MnObject("element", "content"))
// document.Container.Add(new MnSet("etree", new MnObject[]))
// 
// var document = new MnDocument(
//      "Document",
//      new List<MnObject> 
//      {
//          // etc
//      }
// )

open System.IO

/// <summary>
/// Представление MOON документа
/// </summary>
type MoonDocument (name:string, content: MoonSet) = 
    new () = MoonDocument("object", MoonSet())
    
    member this.Container: MoonSet = content
    member this.Name:string = name

    /// <summary>
    /// Возвращает элемент нотации в виде строки
    /// </summary>
    member this.createElement (mno:MoonElement) = 
        $"{mno.Name}=\"{mno.Content}\"\n"

    /// <summary>
    /// Возврашает список элементов в виде строки
    /// </summary>
    member this.createList (mnl:MoonList) = 
        $"""{mnl.Name}=[{[for i in mnl.Content do yield $"{i};"]}];\n"""

    /// <summary>
    /// Возвращает комментарий
    /// </summary>
    member this.createComment (com: string) = 
        $"?{{{com}}}\n"

    /// <summary>
    /// Сохраняет документ
    /// </summary>
    member this.save(path:string): int = 
        let mutable doc: string = 
            this.Name + "=(" + "\t"
        
        for l in this.Container.Lists do
            doc <- ("\t" + this.createList(l))
        for e in this.Container.Elements do
            doc <- ("\t" + this.createElement(e))
        doc <- ");"
        
        File.WriteAllText(path, doc)
        0

        