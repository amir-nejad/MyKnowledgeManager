export interface KnowledgeTagDTO {
  id: string,
  tagName: string,
  createdDate?: Date,
  updatedDate?: Date,
  isTrashItem: boolean,
  userId: string
}