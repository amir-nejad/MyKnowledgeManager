export interface KnowledgeTag {
  id: string | null,
  tagName: string,
  createdDate?: Date,
  updatedDate?: Date,
  isTrashItem: boolean,
  userId: string | null
}