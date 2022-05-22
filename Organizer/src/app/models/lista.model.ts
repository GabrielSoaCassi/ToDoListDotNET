import { Tarefa } from "./tarefa.model";

export interface Lista{
  id?:number;
  nome:string;
  tarefas?:Tarefa[];
}
