/**
 * This interface is used for mapping the api response of KnowledgeTag and using as a model for angular app.
 */
export interface KnowledgeTag {
  id: string | null,
  tagName: string,
  createdDate?: Date,
  updatedDate?: Date,
  isTrashItem: boolean,
  userId: string | null
}