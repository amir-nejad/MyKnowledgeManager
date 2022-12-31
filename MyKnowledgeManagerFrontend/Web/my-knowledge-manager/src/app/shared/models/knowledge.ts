import { KnowledgeImportance, KnowledgeLevel } from "..";

/**
 * This interface is used for mapping the api response of Knowledge and using as a model for angular app.
 */
export interface Knowledge {
  id: string | null,
  title: string,
  description: string,
  knowledgeImportance: KnowledgeImportance,
  knowledgeLevel: KnowledgeLevel,
  knowledgeTags: string[],
  createdDate?: Date,
  updatedDate?: Date,
  isTrashItem: boolean,
  userId: string
}