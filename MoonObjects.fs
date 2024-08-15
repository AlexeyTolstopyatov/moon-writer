namespace MoonDocument

/// <summary>
/// Представление списка для нотации.
/// </summary>
type MoonList (name:string, content:obj[]) = 
    member this.Name:string = name
    member this.Content:obj[] = content
    
    new () = MoonList("", [||])

/// <summary>
/// Представление понятия элемента для нотации
/// </summary>
type MoonElement(name:string, content:string) = 
    member this.Name:string = name
    member this.Content:string = content

    new () = MoonElement("", "")

/// <summary>
/// Представление множества
/// </summary>
type MoonSet (name:string, lists: MoonList list, elements: MoonElement list) = 
    member this.Name = name
    member this.Lists = lists
    member this.Elements = elements
    new () = MoonSet("", [], [])