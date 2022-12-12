export interface KnowledgeTag {
  id: string,
  tagName: string,
  createdDate?: Date,
  updatedDate?: Date,
  isTrashItem: boolean,
  userId: string
}