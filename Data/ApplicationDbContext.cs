using E_Exam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Exam.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> // i'd Used ApplicationUser instead of IdentityUser for more customization and flexablity
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }
        public DbSet<UserExam> UserExams { get; set; } // Add UserExam DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add unique constraints
            modelBuilder.Entity<Subject>()
                .HasIndex(s => s.Name)
                .IsUnique();

            modelBuilder.Entity<Chapter>()
                .HasIndex(c => new { c.SubjectId, c.Name })
                .IsUnique();
            // UserExam relationships
            modelBuilder.Entity<UserExam>()
                .HasKey(ue => ue.Id); // Use the new surrogate key as the primary key

            modelBuilder.Entity<UserExam>()
                .HasIndex(ue => new { ue.UserId, ue.ExamId })
                .IsUnique(); // Add a unique constraint on the combination of UserId and ExamId

            modelBuilder.Entity<UserExam>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserExams)
                .HasForeignKey(ue => ue.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Change the delete behavior to NoAction

            modelBuilder.Entity<UserExam>()
                .HasOne(ue => ue.Exam)
                .WithMany(e => e.UserExams)
                .HasForeignKey(ue => ue.ExamId)
                .OnDelete(DeleteBehavior.NoAction); // Change the delete behavior to NoAction
            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Chapters)
                .WithOne(c => c.Subject)
                .HasForeignKey(c => c.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Exams)
                .WithOne(e => e.Subject)
                .HasForeignKey(e => e.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Chapter>()
                .HasMany(c => c.Questions)
                .WithOne(q => q.Chapter)
                .HasForeignKey(q => q.ChapterId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Exam>()
                .HasMany(e => e.ExamQuestions)
                .WithOne(eq => eq.Exam)
                .HasForeignKey(eq => eq.ExamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ExamQuestion>()
                .HasOne(eq => eq.Question)
                .WithMany()
                .HasForeignKey(eq => eq.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExamQuestion>()
                .HasMany(eq => eq.StudentAnswers)
                .WithOne(sa => sa.ExamQuestion)
                .HasForeignKey(sa => sa.ExamQuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentAnswer>()
                .HasOne(sa => sa.Answer)
                .WithMany()
                .HasForeignKey(sa => sa.AnswerId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<E_Exam.Models.Department> Department { get; set; } = default!;

        public DbSet<E_Exam.Models.ExamResult> ExamResult { get; set; } = default!;

        public DbSet<E_Exam.Models.ExamStructure> ExamStructure { get; set; } = default!;

        public DbSet<E_Exam.Models.Level> Level { get; set; } = default!;

        public DbSet<E_Exam.Models.MCQQuestion> MCQQuestion { get; set; } = default!;

        public DbSet<E_Exam.Models.QuestionResult> QuestionResult { get; set; } = default!;

        public DbSet<E_Exam.Models.QuestionStatistics> QuestionStatistics { get; set; } = default!;

        public DbSet<E_Exam.Models.StudentRank> StudentRank { get; set; } = default!;

        public DbSet<E_Exam.Models.StudentResult> StudentResult { get; set; } = default!;

        public DbSet<E_Exam.Models.SubjectProfessor> SubjectProfessor { get; set; } = default!;

        public DbSet<E_Exam.Models.TrueFalseQuestion> TrueFalseQuestion { get; set; } = default!;
    }
}