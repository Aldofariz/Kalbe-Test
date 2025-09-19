import { Geist, Geist_Mono } from "next/font/google";
import "./globals.css";
import AppSideBar from "@/components/AppSideBar";
import Navbar from "@/components/Navbar";
import { SidebarProvider } from "@/components/ui/sidebar";

const geistSans = Geist({
  variable: "--font-geist-sans",
  subsets: ["latin"],
});

const geistMono = Geist_Mono({
  variable: "--font-geist-mono",
  subsets: ["latin"],
});

export const metadata = {
  title: "Master Dashboard",
  description: "Technical Test from Kalbe",
};

export default function RootLayout({ children }) {
  return (
    <html lang="en">
      <body
        className={`${geistSans.variable} ${geistMono.variable} antialiased flex`}
      >
        <SidebarProvider>
        <AppSideBar/>
        <main className="w-full">
          <Navbar/>
          <div>
            {children}
          </div>
        </main>
        </SidebarProvider>
      </body>
    </html>
  );
}
