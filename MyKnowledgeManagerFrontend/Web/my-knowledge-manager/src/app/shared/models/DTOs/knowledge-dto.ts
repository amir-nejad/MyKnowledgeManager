import { KnowledgeImportance, KnowledgeLevel } from "../..";

export interface KnowledgeDTO {
  id: string,
  title: string,
  description: string,
  knowledgeImportance: KnowledgeImportance,
  knowledgeLevel: KnowledgeLevel,
  knowledgeTags: string[],
  createdDate: string,
  updatedDate: string,
  isTrashItem: boolean,
  userId: string
}