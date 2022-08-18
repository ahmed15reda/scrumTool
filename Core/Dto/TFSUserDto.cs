namespace Core.Dto
{
    public class TFSUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int UserRole { get; set; }
        public int DepartmentId { get; set; }
        public int SquadId { get; set; }
        public string Name { get; set; }
        public string TFSName { get; set; }
        public string ProfileImgUrl { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
