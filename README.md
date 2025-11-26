<h1 align="center">🚀 Freedom – Service Marketplace (ASP.NET Core MVC)</h1>

<p align="center">
  <strong>A custom service marketplace built with ASP.NET Core MVC</strong><br/>
  Listings, workers, admin approval workflow & clean architecture.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/stack-ASP.NET%20Core%20MVC-blue" />
  <img src="https://img.shields.io/badge/database-SQL%20Server-success" />
  <img src="https://img.shields.io/badge/style-Bootstrap%205-informational" />
  <img src="https://img.shields.io/badge/status-Work%20in%20Progress-yellow" />
</p>

<hr/>

## 🧠 Project Idea

<p>
  <strong>Freedom</strong> is a service marketplace where clients create job listings (tasks, gigs, work requests)
  and connect with workers based on category and availability.
</p>

<p>The main goals of the project are:</p>

<ul>
  <li>Build a realistic, production-style <strong>ASP.NET Core MVC</strong> application</li>
  <li>Practice <strong>clean architecture</strong>, Identity, areas, and admin workflows</li>
  <li>Use it as a <strong>portfolio project</strong> to land a remote C#/.NET developer position</li>
  <li>Provide a solid foundation for future extensions and side projects</li>
</ul>

<hr/>

## ✨ Current Features

### 👤 Public Users

<ul>
  <li>Register / log in via ASP.NET Core Identity</li>
  <li>Create job listings with:
    <ul>
      <li>Title</li>
      <li>Description</li>
      <li>Budget</li>
      <li>Category (worker type)</li>
      <li>Location address</li>
    </ul>
  </li>
  <li>Browse <strong>approved &amp; active</strong> listings</li>
  <li>View <strong>My Listings</strong> (including Pending and Rejected)</li>
  <li>Edit or delete their own listings</li>
</ul>

<hr/>

## 🛠 Listings Workflow

<p>Each listing has:</p>

<ul>
  <li><code>ListingStatus</code>:
    <ul>
      <li><code>Pending</code> – created by user, waiting for admin review</li>
      <li><code>Active</code> – visible to everyone</li>
      <li><code>Assigned</code> – taken by a worker</li>
      <li><code>Completed</code> – finished jobs</li>
      <li><code>Rejected</code> – rejected by admin, not public</li>
    </ul>
  </li>
  <li><code>IsApproved</code> – controls public visibility</li>
</ul>

<p>Current flow:</p>

<ol>
  <li>User creates listing → <code>Status = Pending</code>, <code>IsApproved = false</code></li>
  <li>Admin approves → <code>Status = Active</code>, <code>IsApproved = true</code></li>
  <li>Admin rejects → <code>Status = Rejected</code>, <code>IsApproved = false</code></li>
</ol>

<hr/>

## 👷 Worker System

<p>
  Any authenticated user can be associated with a <strong>Worker</strong> profile.
  Workers can be approved or rejected by an admin.
</p>

<ul>
  <li>Each worker has:
    <ul>
      <li>Phone number</li>
      <li>Years of experience</li>
      <li><code>WorkerTypeCategory</code> (Plumber, Electrician, etc.)</li>
      <li><code>WorkerStatus</code>:
        <ul>
          <li><code>Pending</code> – waiting for review</li>
          <li><code>Active</code> – able to take listings</li>
          <li><code>Rejected</code> – not allowed to take listings</li>
        </ul>
      </li>
    </ul>
  </li>
  <li>Only <strong>Active</strong> workers are expected to work with assigned jobs</li>
</ul>

<hr/>

## 🛡 Admin Area

<p>
  The application includes a dedicated <strong>Admin Area</strong> under
  <code>/Admin</code> with its own controllers and views.
</p>

<h4>🔐 Security</h4>

<ul>
  <li>Access restricted via:
    <ul>
      <li><code>[Area("Admin")]</code></li>
      <li><code>[Authorize(Roles = "Admin")]</code></li>
    </ul>
  </li>
  <li>Data-changing actions use <code>[ValidateAntiForgeryToken]</code></li>
</ul>

<h4>📋 Admin Features</h4>

<ul>
  <li>Admin dashboard at <code>/Admin</code></li>
  <li>Pending listings management at <code>/Admin/ListingApproval/Pending</code></li>
  <li>Admin can:
    <ul>
      <li><strong>Approve</strong> a listing → becomes publicly visible</li>
      <li><strong>Reject</strong> a listing → archived as Rejected</li>
      <li><strong>Approve</strong> a worker → worker can take listings</li>
      <li><strong>Reject</strong> a worker → treated as a normal user without worker privileges</li>
    </ul>
  </li>
</ul>

<hr/>

## 🧱 Domain Snapshot

<h4>Listing</h4>

<p>Represents a service request / job.</p>

<ul>
  <li>Id, Title, Description, LocationAddress</li>
  <li>Budget</li>
  <li><code>ListingStatus</code>, <code>IsApproved</code></li>
  <li><code>WorkerTypeCategoryId</code> – required</li>
  <li><code>UploaderId</code> – Identity user who created the listing</li>
  <li><code>WorkerId</code> – optional; assigned worker</li>
</ul>

<h4>Worker</h4>

<p>Represents a worker that can take jobs.</p>

<ul>
  <li>Id, PhoneNumber, YearsOfExperience</li>
  <li><code>WorkerStatus</code> (Pending, Active, Rejected)</li>
  <li><code>WorkerTypeCategoryId</code></li>
  <li><code>UserId</code> – 1:1 link to <code>AspNetUsers</code></li>
</ul>

<h4>WorkerTypeCategory</h4>

<p>Defines categories for both listings and workers. Seeded examples:</p>

<ul>
  <li>Plumber</li>
  <li>Electrician</li>
  <li>Gardener</li>
  <li>Cleaner</li>
</ul>

<hr/>

## 🧪 Tech Stack

<ul>
  <li><strong>Backend:</strong> ASP.NET Core 10 MVC</li>
  <li><strong>ORM:</strong> Entity Framework Core 10</li>
  <li><strong>Database:</strong> SQL Server</li>
  <li><strong>Auth:</strong> ASP.NET Core Identity</li>
  <li><strong>UI:</strong> Bootstrap 5</li>
  <li><strong>Architecture:</strong> Controllers → Services → DbContext (clean layering)</li>
</ul>

<hr/>

## ▶️ Getting Started

<h4>1. Clone the repository</h4>

```bash
git clone https://github.com/stefanzcu/freedom.git
cd freedom
```

<h4>2. Configure the database</h4>

<p>Update your connection string in <code>appsettings.json</code> or <code>secrets.json</code>.</p>

```bash
dotnet ef database update
```

<h4>3. Run the application</h4>

```bash
dotnet run
```

<hr/>

## 🔑 Seeded Accounts (Quick Reference)

<p>
  A <strong>full detailed list</strong> of all seeded users, workers, worker statuses,
  listings, and relationships is available at:
</p>

<pre>
Freedom.Infrastructure/freedom_seed_overview.txt
</pre>

<h4>Admin Account</h4>

<pre>
Email:    admin@freedom.bg
Password: Admin123!
Role:     Admin
</pre>

<h4>Example Regular User</h4>

<pre>
Email:    guest1@gmail.com
Password: guest123
Role:     Normal User
</pre>

<h4>Example Worker (Active)</h4>

<pre>
Email:    plumber.worker@gmail.com
Password: worker123
Role:     Worker (Active)
Category: Plumber
</pre>

<hr/>

## 🧭 Roadmap

<ul>
  <li>✔ Listing approval workflow</li>
  <li>✔ Worker approval workflow</li>
  <li>⏳ Worker dashboard</li>
  <li>⏳ Worker profile pages</li>
  <li>⏳ Improved public UI</li>
  <li>⏳ Additional side projects (e.g., AI-powered meal planner)</li>
</ul>

<hr/>

## 🎯 Why this project matters

<ul>
  <li>Showcases real-world <strong>ASP.NET Core MVC</strong> experience</li>
  <li>Uses <strong>Identity</strong>, roles, areas, and admin workflows</li>
  <li>Implements EF Core migrations and realistic seeding</li>
  <li>Follows clean architecture and layering</li>
  <li>Provides a <strong>portfolio-ready</strong> project for .NET job applications</li>
</ul>
